import { InjectionToken } from '@angular/core';

export const BASE_PATH = "https://localhost:44310/"// new InjectionToken<string>('basePath');
export const COLLECTION_FORMATS = {
    'csv': ',',
    'tsv': '   ',
    'ssv': ' ',
    'pipes': '|'
}
