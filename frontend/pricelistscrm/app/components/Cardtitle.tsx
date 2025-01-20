interface Props {
    id: string;
    title: string;
}
export const CardTitle = ({id, title}: Props) => {
    return (
        <div style={{
            display: "flex",
            flexDirection: "row",
            alignItems: "center",
            justifyContent: "space-between",
        }}>
            <p className="card__id">{id}</p>
            <p className="card__title">{title}</p>
        </div>
    )
}