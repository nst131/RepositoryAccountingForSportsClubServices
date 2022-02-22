import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { HeadersEnum } from "src/app/models/headers.enum";
import { UserUpdateModel } from "../models/user-update.model";
import { User } from "../models/user.model";

@Injectable()
export class UserService {
    private url = "https://localhost:5001/v1/User";
    private urlAuth = "https://localhost:5002/api/Auth/DeleteUserByEmail";

    constructor(private http: HttpClient) { }

    public getUsers(): Observable<Array<User>> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Array<User>>(this.url + '/' + 'GetAll', { headers: myHeaders });
    }

    public getUserIdByEmail(email: string): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify({ email: email });
        return this.http.post<number>(this.url + '/' + 'GetIdByEmail', body, { headers: myHeaders });
    }

    public getUser(id: number): Observable<User> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<User>(this.url + '/' + "Get" + '/' + id, { headers: myHeaders });
    }

    public updateUser(obj: UserUpdateModel): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(obj);
        return this.http.put<any>(this.url + '/' + 'Update', body, { headers: myHeaders });
    }

    public deleteUser(id: number, email: string): Array<Observable<any>> {
        let arrayObservable: Array<Observable<any>> = [];
        arrayObservable.push(this.deleteUserOnAuth(email));
        arrayObservable.push(this.deleteUserOnMain(id));

        return arrayObservable;
    }

    private deleteUserOnAuth(email: string): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify({ email: email });
        return this.http.post(this.urlAuth, body, { headers: myHeaders });
    }

    private deleteUserOnMain(id: number): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.delete(this.url + '/' + 'Delete' + '/' + id, { headers: myHeaders });
    }
}