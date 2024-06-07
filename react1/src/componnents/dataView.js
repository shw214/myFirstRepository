

import React, { useState, useEffect } from 'react';

import { Button } from 'primereact/button';
import { DataView } from 'primereact/dataview';
import { Rating } from 'primereact/rating';
import { Tag } from 'primereact/tag';
import { classNames } from 'primereact/utils';
import { GetAllPresent,GetPresentByDonor,UpdatePresent,postPresent,GetPresentByName } from '../axios/PresentApi';

export default function BasicDemo() {
    const [present, setPresent] = useState([]);

    useEffect(() => {
    //GetAllPresent().then((data) => setPresent(data.slice(0, 5)));
    const a= GetAllPresent();
    setPresent(a)
    }, []);

  
    const itemTemplate = (present, index) => {
        console.log("hbuhbu")
        return (
            
            <div/* className="col-12"*/ key={present.id}>
                
                <div className={classNames('flex flex-column xl:flex-row xl:align-items-start p-4 gap-4', { 'border-top-1 surface-border': index !== 0 })}>❤❤❤
                        {/* <img className="w-9 sm:w-16rem xl:w-10rem shadow-2 block xl:block mx-auto border-round" 
                        src={`https://primefaces.org/cdn/primereact/images/product/${present.image}`} alt={present.name} /> */}
                    <div className="flex flex-column sm:flex-row justify-content-between align-items-center xl:align-items-start flex-1 gap-4">
                        <div className="flex flex-column align-items-center sm:align-items-start gap-3">
                            <div className="text-2xl font-bold text-900">"UHIOIU"</div>
                            {/* <Rating value={present.rating} readOnly cancel={false}></Rating> */}
                            <div className="flex align-items-center gap-3">
                                <span className="flex align-items-center gap-2">
                                    <i className="pi pi-tag"></i>
                                    <span className="font-semibold">GFHHTRHTR</span>
                                </span>
                              {/* //  <Tag value={present.inventoryStatus} severity={getSeverity(present)}></Tag> */}
                            </div>
                        </div>
                        <div className="flex sm:flex-column align-items-center sm:align-items-end gap-3 sm:gap-2">
                            <span className="text-2xl font-semibold">GTRHDSTR</span>
                            <Button icon="pi pi-shopping-cart" className="p-button-rounded" disabled={present.inventoryStatus === 'OUTOFSTOCK'}></Button>
                        </div>
                    </div>
                </div>
            </div>
        );
    };

    const listTemplate = (items) => {

        debugger
        if (!items || items.length === 0) return null;

        let list = items.map((present, index) => {
            return itemTemplate(present, index);
        });

        return <div className="grid grid-nogutter">HJKG</div>;
    };

    return (
        <div className="card">
            <DataView value={present} listTemplate={listTemplate} />
        </div>
    )
}

        