import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class ItensPedidoDataService {
    module: string = '/api/itenspedido';

    constructor(private http: HttpClient) { }

    get(id) {
        let data = {"id": id};
        return this.http.get(this.module, {params: data});
    }

    post(data) {
        return this.http.post(this.module, data);
    }

    put(data) {
        return this.http.put(this.module, data);
    }
}