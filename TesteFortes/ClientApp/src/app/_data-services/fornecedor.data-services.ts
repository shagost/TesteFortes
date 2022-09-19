import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class FornecedorDataService {
    module: string = '/api/fornecedor';

    constructor(private http: HttpClient) { }

    get() {
        return this.http.get(this.module);
    }

    post(data) {
        return this.http.post(this.module, data);
    }

    put(data) {
        return this.http.put(this.module, data);
    }

    delete(id){
        return this.http.delete(this.module + '/' + id);
    }
}