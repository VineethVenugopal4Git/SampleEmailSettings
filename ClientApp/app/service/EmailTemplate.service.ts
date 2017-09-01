import { Injectable } from '@angular/core';
import { Email, IEmail } from '../models/Email';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ApiResponse } from '../models/response';
import { Query } from "../models/query";
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class EmailTemplateService {

    constructor(private http: Http) { }
   
    getEmail(query: Query): Observable<ApiResponse> {

        return this.http.get("EmailSetting/Get" + '?' + this.toQueryString(query))
            .map((response: Response) => <ApiResponse[]>response.json())
            .catch(this.handleError);
    }

   


    create(email: IEmail): Observable<ApiResponse> {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post("EmailSetting/Post", email, { headers: headers })
            .map((response: Response) => <ApiResponse>response.json())
            .catch(this.handleError);
    }

    update(email: IEmail): Observable<ApiResponse> {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post("EmailSetting/Put", email, { headers: headers })
            .map((response: Response) => <ApiResponse>response.json())
            .catch(this.handleError);
    }

    delete(email: IEmail): Observable<ApiResponse> {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        return this.http.post("EmailSetting/Delete", email, { headers: headers })
            .map((response: Response) => <ApiResponse>response.json())
            .catch(this.handleError);
    }

    toQueryString(obj) {
        var parts = [];
        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined) {
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
            }
        }
        return parts.join("&");
    }
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}