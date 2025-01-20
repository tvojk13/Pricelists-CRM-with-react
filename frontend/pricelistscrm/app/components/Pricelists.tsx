import Card from "antd/es/card/Card"
import { CardTitle } from "./Cardtitle"
import Button from "antd/es/button/button"

interface Props {
    pricelists: Pricelist[]
    handleDelete: (id: number) => void;
    handleOpen: (pricelist: Pricelist) => void;
}

export const Pricelists = ({ pricelists, handleOpen, handleDelete }: Props) =>{
    return (
        <div className="cards">
            { pricelists.map((pricelist : Pricelist) => (
                <Card 
                    key={pricelist.id} 
                    title={<CardTitle id={pricelist.id.toString()} title={pricelist.title}/>} 
                    bordered={false} 
                >
                
                <p>{pricelist.text}</p>
                <p>{pricelist.number}</p>
                <p>{new Date(pricelist.date).toLocaleDateString('en-US', { year: 'numeric', month: 'long', day: 'numeric' })}</p>

                <div className="card__buttons">
                    <Button 
                        onClick={() => handleOpen(pricelist)}
                        style={{ flex: 1 }}
                        >
                            Edit
                    </Button>
                    
                    <Button 
                        onClick={() => handleDelete(pricelist.id)}
                        danger
                        style={{ flex: 1 }}
                        >
                            Delete
                    </Button>
                </div>
                
                </Card>
            ))}
        </div>
    )
}