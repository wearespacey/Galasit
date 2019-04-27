import { Bubble } from './bubble';
import { Seat } from './seat';

export interface Table {
  id: string;
  bubble: Bubble;
  seats: Seat[];
}
