import React, { useState, useEffect } from 'react';
import authService from './api-authorization/AuthorizeService'
import { ResourcesBox } from './ResourcesBox';
import { UpgradeBox } from './UpgradeBox';
import { ManufactureBox } from './ManufactureBox';

export const DomikiPage = () => {
    const [domiks, setDomiks] = useState({});
    const [selectedDomik, setSelectedDomik] = useState(null);
    const [selectedDomikId, setSelectedDomikId] = useState(null);
    const [selectedDomikReceipts, setSelectedDomikReceipts] = useState(null);

    const [domikTypes, setDomikTypes] = useState([]);
    const [resources, setResources] = useState([]);
    const [resourceTypes, setResourceTypes] = useState([]);
    const [purchaseDomikTypes, setPurchaseDomikTypes] = useState([]);
    const [purchaseDomikTypesVisible, setPurchaseDomikTypesVisible] = useState([]);
    const [modificatorTypes, setModificatorTypes] = useState([]);
    const [receipts, setReceipts] = useState([]);
    const [plodderCount, setPlodderCount] = useState(null);

    useEffect(() => {
        setPurchaseDomikTypes(null);
        getPurchaseDomikTypes();
        async function myFunc() {
            sendRequest('GET', 'Domiki/GetDomikTypes', function (data) {
                setDomikTypes(data);
            });
            sendRequest('GET', 'Domiki/GetResourceTypes', function (data) {
                setResourceTypes(data);
            });
            sendRequest('GET', 'Domiki/GetModificatorTypes', function (data) {
                setModificatorTypes(data);
            });
            sendRequest('GET', 'Domiki/GetReceipts', function (data) {
                setReceipts(data);
            });
            getDomiks();
            getResources();
        }

        myFunc();

    }, []);


    useEffect(() => {
        const interval = setInterval(function () {
            var result = IntervalTick(domiks.items);
            if (result) {
                setDomiks({ items: domiks.items });
            }
        }, 1000);

        return () => {
            if (interval != null) {
                clearInterval(interval);
            }
        };

    }, [domiks]);

    useEffect(() => {
        let maxPlodderCount = 0;
        let workingPlodderCount = 0;
        if (domikTypes != null && domikTypes.length > 0 && domiks != null && domiks.items != null) {
            domiks.items.forEach(function (domik) {
                let domikType = domikTypes.filter(x => x.id === domik.typeId)[0];
                if (domik.level > 0) {
                    let domiklevel = domikType.levels.filter(x => x.value === domik.level)[0];
                    let plodderTypeId = 1;
                    let modificators = domiklevel.modificators.filter(x => x.typeId === plodderTypeId);
                    if (modificators.length > 0) {
                        maxPlodderCount += modificators[0].value;
                    }
                }
                if (domik.manufactures != null) {
                    domik.manufactures.forEach(function (manufacture) {
                        workingPlodderCount += manufacture.plodderCount;
                    });
                }
            });
        }

        setPlodderCount({ max: maxPlodderCount, free: maxPlodderCount - workingPlodderCount });
        selectDomik(selectedDomikId);

    }, [domiks, domikTypes]);

    useEffect(() => {
        let selectedDomikReceipts = [];
        if (selectedDomik != null && receipts.length > 0 && selectedDomik.level > 0) {
            let domikType = domikTypes.filter(x => x.id === selectedDomik.typeId)[0];
            let domikLevel = domikType.levels.filter(x => x.value === selectedDomik.level)[0];
            domikLevel.receiptIds.forEach(function (receiptId) {
                let receipt = receipts.filter(x => x.id === receiptId)[0];
                selectedDomikReceipts.push(receipt);
            });
            selectedDomik.receipts = selectedDomikReceipts;
            selectedDomik.domikType = domikType;
            if (selectedDomik.level < selectedDomik.domikType.maxLevel
                && selectedDomik.durationSeconds == null) {
                let hasResources = true;
                domikLevel.resources.forEach(function (resource) {
                    console.log(resource)
                    var resourcesForUpgrade = resources.filter(x => x.typeId === resource.typeId);
                    console.log(resourcesForUpgrade)
                    if (resourcesForUpgrade.length === 0 || resourcesForUpgrade[0].value < resource.value) {
                        hasResources = false;
                    }
                });
                selectedDomik.upgradeAvailable = true;
                selectedDomik.upgradeHasResources = hasResources;
                selectedDomik.upgradeResources = domikLevel.resources;
            }
        }
    }, [selectedDomik, receipts, resources]);

    function IntervalTick(domikItems) {
        if (domikItems != null) {
            domikItems.forEach(function (domik) {
                if (domik.finishDate != null) {
                    let date = new Date();
                    let seconds = (new Date(domik.finishDate).getTime() - date.getTime()) / 1000;
                    let time = getTimeFromSecond(seconds);
                    domik.durationSecondsText = time;
                    domik.durationSeconds = seconds;
                    if (seconds <= 0) {
                        getDomiks();
                        return false;
                    }
                }
                if (domik.manufactures != null) {
                    domik.manufactures.forEach(function (manufacture) {
                        let date = new Date();
                        let seconds = (new Date(manufacture.finishDate).getTime() - date.getTime()) / 1000;
                        let time = getTimeFromSecond(seconds);
                        manufacture.durationSecondsText = time;
                        manufacture.durationSeconds = seconds;
                        if (seconds <= 0) {
                            getDomiks();
                            getResources();
                            return false;
                        }
                    });
                }
            })
        }
        return true;
    }

    function getTimeFromSecond(totalSeconds) {
        totalSeconds = Math.round(totalSeconds, 0);
        var seconds = totalSeconds % 60;
        var minuts = parseInt(totalSeconds / 60);
        var hours = 0;
        var days = 0;
        if (minuts > 0) {
            hours = parseInt(minuts / 60);
            minuts = minuts % 60;
        }
        if (hours > 0) {
            days = parseInt(hours / 24);
            hours = hours % 24;
        }
        var showInfo = "";
        if (days > 0) {
            if (days < 10) {
                days = '0' + days;
            }
            showInfo += days + "д ";
        }
        if (hours > 0 || days > 0) {
            if (hours < 10) {
                hours = '0' + hours;
            }
            showInfo += hours + "ч ";
        }
        if (minuts > 0 || days > 0 || hours > 0) {
            if (minuts < 10) {
                minuts = '0' + minuts;
            }
            showInfo += minuts + "м ";
        }
        if (days === 0) {
            if (seconds < 10) {
                seconds = '0' + seconds;
            }
            showInfo += seconds + "с ";
        }
        return showInfo;

    }


    async function getDomiks() {
        sendRequest('GET', 'Domiki/GetDomiks', function (data) {
            IntervalTick(data)
            setDomiks({ items: data });
        });
    }

    async function getResources() {
        sendRequest('GET', 'Domiki/GetResources', function (data) {
            setResources(data);
        });
    }

    async function upgrade(id) {
        sendRequest('POST', 'Domiki/UpgradeDomik/' + id, function (data) {
            getDomiks();
            getResources();
        });
    }

    async function selectDomik(id) {
        if (domiks.items != null) {
            domiks.items.forEach(function (domik) {
                if (domik.id === id) {
                    setSelectedDomik(domik);
                    setSelectedDomikId(id);
                    return;
                }
            });
        }
    }

    async function startManufacture(domikId, receiptId) {
        sendRequest('POST', 'Domiki/StartManufacture/' + domikId + '/' + receiptId, function (data) {
            getDomiks();
            getResources();
        });
    }

    async function showPurchaseDomikWindow() {
        if (purchaseDomikTypesVisible === true) {
            setPurchaseDomikTypesVisible(false);
        } else {
            setPurchaseDomikTypesVisible(true);
            if (purchaseDomikTypes == null) {
                getPurchaseDomikTypes();
            }
        }
    }

    async function getPurchaseDomikTypes() {
        sendRequest('GET', 'Domiki/GetPurchaseAvaialableDomiks', function (data) {
            setPurchaseDomikTypes(data);
        });
    }

    async function buy(typeId) {
        sendRequest('POST', 'Domiki/BuyDomik/' + typeId, function (data) {
            getDomiks();
            getResources();
            getPurchaseDomikTypes();
        });
    }

    // todo переместить в сервис какойнить
    async function sendRequest(method, url, succesAction) {
        const token = await authService.getAccessToken();
        const requestOptions = {
            method: method,
            headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
        };
        fetch(url, requestOptions)
            .then((res) => res.json())
            .then((data) => {
                if (data.type === 2) {
                    alert(data.content);
                } else {
                    succesAction(data.content);
                }
            })
            .catch((err) => {
                console.log(err.message);
            });
    }

    return (
        <div className="App">
            <div>
                {plodderCount != null &&
                    <div>
                        <img src="/images/modificatorTypes/plodder.png" alt="Трудяги"></img>
                        <label>{plodderCount.free}/{plodderCount.max}</label>
                    </div>
                }
            </div>
            <div className="resources">
                {resourceTypes != null && resourceTypes.length > 0 &&
                    resources.map((resource, index) => {
                        let resourceType = resourceTypes.filter(x => x.id === resource.typeId)[0];
                        let image = "/images/resourceTypes/" + resourceType.logicName + ".png";
                        return (
                            <div key={index} className="resource-box">
                                <img src={image} alt={resourceType.name} />
                                <label className="resource-value">{resource.value}</label>
                            </div>
                        );
                    })
                }</div>
            <div className="workspace">
                <div className="domiks">
                    {domikTypes != null && domikTypes.length > 0 && domiks.items != null &&
                        domiks.items.map((domik, index) => {
                            let domikType = domikTypes.filter(x => x.id === domik.typeId)[0];
                            let image = "/images/domikTypes/" + domikType.logicName + ".png";
                            let hasManufacture = domik.manufactures != null && domik.manufactures.length > 0;
                            return (
                                <div key={index} className="domik-box" onClick={() => selectDomik(domik.id)}>
                                    <img src={image} alt={domikType.name} />
                                    <div className="break" />
                                    <UpgradeBox durationSeconds={domik.durationSecondsText} level={domik.level} />
                                    <div className="break" />
                                    {domik.level < domikType.maxLevel && domik.durationSeconds == null &&
                                        <img className="manufacture-icon" src="/images/upgrade_available.png" alt="Доступно улучшение" />

                                    }
                                    {domik.durationSeconds != null &&
                                        <img className="manufacture-icon" src="/images/upgrade_in_process.png" alt="Доступно улучшение" />
                                    }
                                    {domik.manufactures != null && domik.manufactures.length > 0 &&
                                        <img className="manufacture-icon" src="/images/manufacture.png" alt="Производство в процессе" />
                                    }
                                </div>
                            );
                        })
                    }
                </div>
                <div className="actions">
                    <div>
                        {selectedDomik != null && selectedDomik.domikType != null &&
                            <div>
                                <label>{selectedDomik.domikType.name}</label>
                                <label style={{ paddingLeft: '10px' }}>{selectedDomik.level}</label>
                            </div>
                        }
                        {selectedDomik != null
                            && selectedDomik.upgradeAvailable
                            && !selectedDomik.upgradeHasResources &&
                            <div>
                                <img src="/images/upgrade_no_resources.png" alt="Не хватает ресурсов" />
                            </div>
                        }
                        {selectedDomik != null
                            && selectedDomik.upgradeAvailable
                            && selectedDomik.upgradeHasResources &&
                            <div>
                                <button onClick={() => upgrade(selectedDomik.id)}>
                                    <ResourcesBox resources={selectedDomik.upgradeResources} resourceTypes={resourceTypes} />улучшить</button>
                            </div>
                        }
                    </div>
                    <div>
                        <label>Добавить производство:</label>
                        {selectedDomik != null && selectedDomik.receipts != null &&
                            selectedDomik.receipts.map((receipt, index) => {
                                return (
                                    <div key={index}>
                                        <button onClick={() => startManufacture(selectedDomik.id, receipt.id)}>{receipt.name}</button>
                                    </div>
                                );
                            })
                        }
                    </div>
                    <div>
                        <label>Текущие производство:</label>
                        {selectedDomik != null && selectedDomik.manufactures != null && receipts != null &&
                            selectedDomik.manufactures.map((manufacture, index) => {
                                return (
                                    <div key={index}>
                                        <ManufactureBox manufacture={manufacture} receipts={receipts}></ManufactureBox>
                                    </div>
                                );
                            })
                        }
                    </div>
                </div>
            </div>
            {purchaseDomikTypes != null && purchaseDomikTypes.length > 0 &&
                <div style={{ marginTop:"10px"}} >
                    <button onClick={() => showPurchaseDomikWindow()}>Магазин</button>
                    <div className="purchase-box">
                        {purchaseDomikTypesVisible === true &&
                            purchaseDomikTypes.map((purchaseDomikType, index) => {
                                let image = "/images/domikTypes/" + purchaseDomikType.logicName + ".png";
                                return (
                                    <div key={index} className="domik-box">
                                        <img src={image} alt={purchaseDomikType.name} />
                                        <ResourcesBox resources={purchaseDomikType.levels[0].resources} resourceTypes={resourceTypes} />
                                        <button onClick={() => buy(purchaseDomikType.id)}>купить</button>
                                    </div>
                                );
                            })
                        }
                    </div>
                </div>
            }
        </div>
    );
};