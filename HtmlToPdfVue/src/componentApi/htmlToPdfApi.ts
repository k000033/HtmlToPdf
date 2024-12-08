import type { THtmlData } from '@/types/requestType'
import type {TReturnMsg} from '@/types/responseType'
import {apiHtmlToPdf} from '../api/index'
// import type {THtmlData} from '../types/requestType.ts'



export const htmlToPdfAction =async (htmlContent:string):Promise<TReturnMsg>=>{
    const res = await apiHtmlToPdf(htmlContent);
    console.log(res);
    return res.data;
}
