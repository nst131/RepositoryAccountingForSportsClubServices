import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AuthActivateService } from "src/app/Auth/services/auth-activate.service";
import { HeadersEnum } from "src/app/models/headers.enum";
import { CreateTraining } from "../models/create-training.model";
import { Training } from "../models/training.model";
import { UpdateTraining } from "../models/update-training.model";

@Injectable()
export class TrainingService {
      private url = "https://localhost:5001/v1/Training";

      constructor(private http: HttpClient) { }

      public getTrainings(): Observable<Array<Training>> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.get<Array<Training>>(this.url + '/' + 'GetAll', { headers: myHeaders });
      }

      public getTraining(id: number): Observable<Training> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.get<Training>(this.url + '/' + "Get" + '/' + id, { headers: myHeaders });
      }

      public createTrainingByClubCard(obj: CreateTraining): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify(obj);
            return this.http.post<any>(this.url + '/' + 'CreateByClubCard', body, { headers: myHeaders });
      }

      public updateTrainingByClubCard(obj: UpdateTraining): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            const body = JSON.stringify(obj);
            return this.http.put<any>(this.url + '/' + 'UpdateByClubCard', body, { headers: myHeaders });
      }

      public deleteTraining(id: number): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.delete(this.url + '/' + 'Delete' + '/' + id, { headers: myHeaders });
      }

      public getResponsibleIdByTrainingId(id: number): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.get(this.url + '/' + 'GetResponsibleIdByTrainingId' + '/' + id, { headers: myHeaders });
      }

      public getTrainerIdByTrainingId(id: number): Observable<any> {
            const myHeaders = new HttpHeaders()
                  .set("Content-Type", "application/json")
                  .set(HeadersEnum.Authorization, AuthActivateService.getSession()?.token ?? "");
            return this.http.get(this.url + '/' + 'GetTrainerIdByTrainingId' + '/' + id, { headers: myHeaders });
      }
}