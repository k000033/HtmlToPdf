import axios from "axios";
import type { AxiosResponse } from "axios";
import type { THtmlData } from "../types/requestType";
import type { TReturnMsg } from "../types/responseType";
const htmlToPdfRequest = axios.create({
  baseURL: "https://localhost:7015/api/HtmlToPdf",
});




export const apiHtmlToPdf = async (htmlData: string): Promise<AxiosResponse<TReturnMsg>> => {
    const res = await htmlToPdfRequest.post<TReturnMsg>("/htmlToPdfToLocal", {
      HtmlContent:htmlData
    }, {
      headers: {
        "Content-Type": "application/json", // 確保內容類型為 JSON
      },
    });
  
    return res;
  };