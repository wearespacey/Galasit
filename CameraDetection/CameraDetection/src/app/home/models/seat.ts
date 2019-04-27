import { Table } from './table';

export interface Seat {
  id: string;
  occupied: boolean;
  start: Date;
  end: Date;
  table: Table;
}
