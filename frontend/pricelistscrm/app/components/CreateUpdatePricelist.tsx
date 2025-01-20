import { validateHeaderName } from "http";
import { PricelistRequest } from "../services/pricelists";
import { Input, Modal } from "antd";
import { useEffect, useState } from "react";
import TextArea from "antd/es/input/TextArea";

interface Props {
    mode: Mode;
    values: Pricelist;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: PricelistRequest) => void;
    handleUpdate: (id: number, request: PricelistRequest) => void;
}

export enum Mode {
    Create,
    Edit,
}

export const CreateUpdatePricelist = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const [title, setTitle] = useState<string>("");
    const [text, setText] = useState<string>("");
    const [number, setNumber] = useState<number>(0);
    
    useEffect(() => {
        setTitle(values.title)
        setText(values.text)
        setNumber(values.number)
    }, [values])

    const handleOnOk = async () => {
        const pricelistRequest = {title, text, number}
        
        mode == Mode.Create
        ? handleCreate(pricelistRequest)
        : handleUpdate(values.id, pricelistRequest);
    }

    return (
        <Modal 
            title={mode === Mode.Create ? "Add a new pricelist" : "Edit the pricelist"}
            open={isModalOpen}
            cancelText={"Cancel"}
            onOk={handleOnOk}
            onCancel={handleCancel}
        >
            <div className="pricelist__modal">
                <Input
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    placeholder="Title"
                />
                <TextArea
                    value={text}
                    onChange={(e) => setText(e.target.value)}
                    placeholder="Text"
                />
                <Input
                    value={number}
                    onChange={(e) => setNumber(e.target.value)}
                    placeholder="Number"
                />
            </div>
        </Modal>
    )
};