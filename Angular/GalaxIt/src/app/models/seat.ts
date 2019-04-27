export interface Seat {
    id: string,
    occupied: boolean,
    start?: Date,
    end?: Date,
    tableId: string
}