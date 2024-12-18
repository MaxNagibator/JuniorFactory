import React from 'react';

export const ManufactureBox = ({ manufacture, receipts }) => {
    let receipt = receipts.filter(x => x.id === manufacture.receiptId)[0];
    var total = receipt.durationSeconds;
    var current = manufacture.durationSeconds;
    var percent = 100 - parseInt(current * 100 / total);

    return (
        <div className="manufacture-box">
            <progress id="file" max="100" value={percent} className="progress" data-label={manufacture.durationSecondsText}></progress>
            <label>{receipt.name}  </label>
            <img src="/images/modificatorTypes/plodder.png" alt="Трудяги"></img>{manufacture.plodderCount}
        </div>
    );
};