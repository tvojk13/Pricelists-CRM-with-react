"use client";

import { Pricelists } from "../components/Pricelists";
import { CreateUpdatePricelist, Mode } from "../components/CreateUpdatePricelist";
import Button from "antd/es/button/button"

import { useEffect, useState } from "react";
import { createPricelist, deletePricelist, getAllPricelists, PricelistRequest, updatePricelist } from "../services/pricelists";
import Title from "antd/es/typography/Title";


export default function PricelistsPage() {
    const defaultValues = {
        title: "",
        text: "",
        number: 0,
    } as Pricelist

    const [values, setValues] = useState<Pricelist>(defaultValues);

    const [pricelists, setPricelists] = useState<Pricelist[]>([]);
    const [loading, setLoading] = useState(true);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [mode, setMode] = useState(Mode.Create);

    useEffect(() => {
        const getPricelists = async () => {
            const pricelists = await getAllPricelists();
            setLoading(false);
            setPricelists(pricelists);
        };

        getPricelists();
    }, [])

    const handleCreatePricelist = async (request: PricelistRequest) => {
        await createPricelist(request);
        closeModal();

        const pricelists = await getAllPricelists();
        setPricelists(pricelists);
    };

    const handleUpdatePricelist = async (id: number, request: PricelistRequest) => {
        await updatePricelist(id, request);
        closeModal();

        const pricelists = await getAllPricelists();
        setPricelists(pricelists);
    }

    const handleDeletePricelist = async (id: number) => {
        await deletePricelist(id);
        closeModal();

        const pricelists = await getAllPricelists();
        setPricelists(pricelists);
    }
    
    const openModal = () => {
        setMode(Mode.Create);
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setValues(defaultValues);
        setIsModalOpen(false);
    };

    const openEditModal = (pricelist: Pricelist) => {
        setMode(Mode.Edit);
        setValues(pricelist);
        setIsModalOpen(true);
    }

    return (
        <div>
            <Button onClick={openModal} id="new_price_list_btn">Add a new pricelist</Button>

            <CreateUpdatePricelist
                mode={mode} values={values} isModalOpen={isModalOpen}
                handleCreate={handleCreatePricelist}
                handleUpdate={handleUpdatePricelist}
                handleCancel={closeModal}
            />

            {loading ? <Title>Loading...</Title> : <Pricelists pricelists={pricelists} handleOpen={openEditModal} handleDelete={handleDeletePricelist}/>}
        </div>
    )
}