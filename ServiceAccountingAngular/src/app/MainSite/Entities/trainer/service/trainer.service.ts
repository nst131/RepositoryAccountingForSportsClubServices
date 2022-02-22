import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { HeadersEnum } from "src/app/models/headers.enum";
import { TrainerUpdate } from "../models/trainer-update.model";
import { Trainer } from "../models/trainer.model";

@Injectable()
export class TrainerService {
    private url = "https://localhost:5001/v1/Trainer";
    private urlAuth = "https://localhost:5002/api/Auth/DeleteUserByEmail";

    constructor(private http: HttpClient) { }

    public getTrainers(): Observable<Array<Trainer>> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Array<Trainer>>(this.url + '/' + 'GetAll', { headers: myHeaders });
    }

    public getTrainerIdByEmail(email: string): Observable<number> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify({ email: email });
        return this.http.post<number>(this.url + '/' + 'GetIdByEmail', body, { headers: myHeaders });
    }

    public getTrainer(id: number): Observable<Trainer> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.get<Trainer>(this.url + '/' + "Get" + '/' + id, { headers: myHeaders });
    }

    public updateTrainer(obj: TrainerUpdate): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(obj);
        return this.http.put<any>(this.url + '/' + 'Update', body, { headers: myHeaders });
    }

    public deleteTrainer(id: number, email: string): Array<Observable<any>> {
        let arrayObservable: Array<Observable<any>> = [];
        arrayObservable.push(this.deleteTrainerOnAuth(email));
        arrayObservable.push(this.deleteTrainerOnMain(id));

        return arrayObservable;
    }

    private deleteTrainerOnAuth(email: string): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify({ email: email });
        return this.http.post(this.urlAuth, body, { headers: myHeaders });
    }

    private deleteTrainerOnMain(id: number): Observable<any> {
        const myHeaders = new HttpHeaders()
            .set("Content-Type", "application/json")
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        return this.http.delete(this.url + '/' + 'Delete' + '/' + id, { headers: myHeaders });
    }
}