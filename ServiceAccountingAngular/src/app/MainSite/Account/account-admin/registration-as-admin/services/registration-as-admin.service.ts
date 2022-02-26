import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable, of } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { HeadersEnum } from "src/app/models/headers.enum";
import { RegistrationAsAdminModel } from "../models/registration-as-admin.model";

@Injectable()
export class RegistrationAsAdminService {
    private pathRegistrationUser: string = "https://localhost:5002/api/Auth/Registration"

    constructor(private http: HttpClient) { }

    public tryRegistrationAsAdmin(registraoinModel: RegistrationAsAdminModel): Observable<any> {
        const myheaders = new HttpHeaders()
            .set('content-type', 'application/json')
            .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
        const body = JSON.stringify(registraoinModel);
        return this.http.post(this.pathRegistrationUser, body, { headers: myheaders }).pipe(map((data: any) => {
            return of({
                error: false,
                response: data.response
            });
        }),
            catchError((err) => {
                let message;
                let errors = err.error.errors;

                if (errors) {
                    for (var i in errors) {
                        if (errors.hasOwnProperty(i) && typeof (i) !== 'function') {
                            message = errors[i][0].split('Path')[0];
                            break;
                        }
                    }
                }
                else {
                    message = "Не правильный Login или Password";
                }

                return of({
                    error: true,
                    messageError: message
                });
            }))
    };
}