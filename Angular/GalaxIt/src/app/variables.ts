import { InjectionToken } from '@angular/core';

export const BASE_PATH = "http://galaxit.azurewebsites.net/api/";//new InjectionToken<string>('basePath');
export const COLLECTION_FORMATS = {
    'csv': ',',
    'tsv': '   ',
    'ssv': ' ',
    'pipes': '|'
}
