import React from 'react';

export const UpgradeBox = ({ durationSeconds, level }) => {
    let levelText = durationSeconds == null ? level : level + " -> " + (level * 1 + 1);

    return (
        <div className="upgrade-box">
            <div>
                <label className="domik-level">{levelText}</label>
            </div>
            <div className="break" />
            {durationSeconds != null &&
                <div>
                    <label>{durationSeconds}</label>
                    <div className="break" />
                </div>
            }
        </div>
    );
};