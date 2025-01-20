export interface PricelistRequest {
    title: string;
    text: string;
    number: number;
}

export const getAllPricelists = async () => {
    const response = await fetch("https://localhost:7077/Pricelists");

    return response.json();
}

export const createPricelist = async ( pricelistRequest: PricelistRequest) => {
    await fetch("https://localhost:7077/Pricelists", {
        method: "POST",
        headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(pricelistRequest),
    });
}

export const updatePricelist = async ( id: number, pricelistRequest: PricelistRequest) => {
    await fetch(`https://localhost:7077/Pricelists/${id}`, {
        method: "PUT",
        headers: {
            "content-type": "application/json"
        },
        body: JSON.stringify(pricelistRequest),
    });
}

export const deletePricelist = async ( id: number) => {
    await fetch(`https://localhost:7077/Pricelists/${id}`, {
        method: "DELETE",
    });
}