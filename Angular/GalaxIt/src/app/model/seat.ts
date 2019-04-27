/**
 * My API v1
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { Table } from './table';
import { User } from './user';


export interface Seat { 
    id?: string;
    occupied: boolean;
    start?: Date;
    end?: Date;
    table: Table;
    users?: Array<User>;
}
