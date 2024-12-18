import React from 'react';

export const ResourcesBox = ({ resources, resourceTypes }) => {
    return (
        <div className="resources">
            {resources.map((res, resIndex) => {
                let resourceType = resourceTypes.filter(x => x.id === res.typeId)[0];
                let resImage = "/images/resourceTypes/" + resourceType.logicName + ".png";
                return (
                    <div key={resIndex} className="resource-box">
                        <img src={resImage} alt={res.name} />
                        <label className="resource-value">{res.value}</label>
                    </div>
                );
            })
            }
        </div>
    );
};