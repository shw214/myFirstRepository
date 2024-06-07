
import React, { useState, useEffect } from 'react';
import { Button } from 'primereact/button';
import { DataView, DataViewLayoutOptions } from 'primereact/dataview';
import { Rating } from 'primereact/rating';
import { Tag } from 'primereact/tag';
import { classNames } from 'primereact/utils';
import { GetAllPresent} from '../axios/PresentApi';
import { InputIcon } from 'primereact/inputicon';
import { InputText } from 'primereact/inputtext';
import { IconField } from 'primereact/iconfield';
import { TreeSelect } from 'primereact/treeselect';
// import { NodeService } from './service/NodeService';

export default function BasicDemo() {
    const [products, setProducts] = useState([]);
    const [layout, setLayout] = useState('grid');
    const [nodes, setNodes] = useState(null);
    const [selectedNodeKey, setSelectedNodeKey] = useState(null);

    useEffect(() => {
        GetAllPresent().then((data) => setProducts(data.slice(0, 12)));
    }, []);

    useEffect(() => {
        GetAllPresent().then((data) => setNodes(data));
    }, []);

    // const getSeverity = (product) => {
    //     switch (product.inventoryStatus) {
    //         case 'INSTOCK':
    //             return 'success';

    //         case 'LOWSTOCK':
    //             return 'warning';

    //         case 'OUTOFSTOCK':
    //             return 'danger';

    //         default:
    //             return null;
    //     }
    // };

    // const header = (
    //     <div className="flex flex-wrap gap-2 align-items-center justify-content-between">
    //         <h4 className="m-0">Manage Products</h4>
    //         <IconField iconPosition="left">
    //             <InputIcon className="pi pi-search" />
    //             <InputText type="search" onInput={(e) => setGlobalFilter(e.target.value)} placeholder="Search..." />
    //         </IconField>
            
    //     </div>
        
        
    // );

    const listItem = (product, index) => {
        return (
            <div className="col-12" key={product.id}>
                <div className={classNames('flex flex-column xl:flex-row xl:align-items-start p-4 gap-4', { 'border-top-1 surface-border': index !== 0 })}>
                    <img className="w-9 sm:w-16rem xl:w-10rem shadow-2 block xl:block mx-auto border-round" src={"/gift.jpg"} alt={product.name} />
                    <div className="flex flex-column sm:flex-row justify-content-between align-items-center xl:align-items-start flex-1 gap-4">
                        <div className="flex flex-column align-items-center sm:align-items-start gap-3">
                            <div className="text-2xl font-bold text-900">{product.name}</div>
                            {/* <Rating value={product.rating} readOnly cancel={false}></Rating> */}
                            <div className="flex align-items-center gap-3">
                                <span className="flex align-items-center gap-2">
                                    <i className="pi pi-tag"></i>
                                    <span className="font-semibold">{product.category.name}</span>
                                </span>
                                {/* <Tag value={product.inventoryStatus} severity={getSeverity(product)}></Tag> */}
                            </div>
                        </div>
                        <div className="flex sm:flex-column align-items-center sm:align-items-end gap-3 sm:gap-2">
                            <span className="text-2xl font-semibold">${product.price}</span>
                            <Button icon="pi pi-shopping-cart" className="p-button-rounded" disabled={product.inventoryStatus === 'OUTOFSTOCK'}></Button>
                        </div>
                    </div>
                </div>
            </div>
        );
    };

    const gridItem = (product) => {
        return (
            <div className="col-12 sm:col-6 lg:col-12 xl:col-4 p-2" key={product.id}>
                <div className="p-4 border-1 surface-border surface-card border-round">
                    <div className="flex flex-wrap align-items-center justify-content-between gap-2">
                        <div className="flex align-items-center gap-2">
                            <i className="pi pi-tag"></i>
                            <span className="font-semibold">{product.category.name}</span>
                        </div>
                        {/* <Tag value={product.inventoryStatus} severity={getSeverity(product)}></Tag> */}
                    </div>
                    <div className="flex flex-column align-items-center gap-3 py-5">
                        {/* <img className="w-9 shadow-2 border-round" src={`https://primefaces.org/cdn/primereact/images/product/{"🎁"}`} alt={product.name} /> */}
                        <img className="w-9 shadow-2 border-round" src={"/gift.JPG"} alt={product.name} />
                        {/* <div className="w-9 shadow-2 border-round"> {"🎁"}</div> */}

                        <div className="text-2xl font-bold">{product.name}</div>
                        {/* <Rating value={product.rating} readOnly cancel={false}></Rating> */}
                    </div>
                    <div className="flex align-items-center justify-content-between">
                        <span className="text-2xl font-semibold">${product.price}</span>
                        <Button icon="pi pi-shopping-cart" className="p-button-rounded" ></Button>
                    </div>
                </div>
            </div>
        );
    };

    const itemTemplate = (product, layout, index) => {
        if (!product) {
            return;
        }

        if (layout === 'list') return listItem(product, index);
        else if (layout === 'grid') return gridItem(product);
    };

    const listTemplate = (products, layout) => {
        return <div className="grid grid-nogutter">{products.map((product, index) => itemTemplate(product, layout, index))}</div>;
    };

    const header = () => {
        return (
            <div className="flex justify-content-end">
                {/* <IconField iconPosition="left">
                <InputIcon className="pi pi-search" />
                <InputText type="search" placeholder="Search..." />
                onInput={(e) => setGlobalFilter(e.target.value)}
                </IconField> */}
            <TreeSelect 
                value={selectedNodeKey} onChange={(e) => setSelectedNodeKey(e.value)} options={nodes} 
                filter className="md:w-20rem w-full" placeholder="Select Item">
            </TreeSelect>
<span style={{width:"30px"}}>

</span>
                <DataViewLayoutOptions layout={layout} onChange={(e) => setLayout(e.value)} />

            </div>

            
        );
    };

    return (
        <div className="card">
            <DataView value={products} listTemplate={listTemplate} layout={layout} header={header()} />
        </div>
    )
}
        





// import React, { useState, useEffect } from "react";
// import { TreeSelect } from 'primereact/treeselect';
// import { NodeService } from './service/NodeService';

// export default function FilterDemo() {
//     const [nodes, setNodes] = useState(null);
//     const [selectedNodeKey, setSelectedNodeKey] = useState(null);
    
//     useEffect(() => {
//         NodeService.getTreeNodes().then((data) => setNodes(data));
//     }, []);

//     return (
//         <div className="card flex justify-content-center">
//             <TreeSelect value={selectedNodeKey} onChange={(e) => setSelectedNodeKey(e.value)} options={nodes} 
//                 filter className="md:w-20rem w-full" placeholder="Select Item"></TreeSelect>
//         </div>
//     );
// }
        