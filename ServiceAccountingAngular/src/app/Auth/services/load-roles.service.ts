import { Injectable} from "@angular/core";

@Injectable()
export class loadRolesService{
    public roles: string[] = [
        "Administrator",
        "User",
        "Responsible",
        "Trainer"
    ];

    public getRoles(): string[]{
        return this.roles;
    }
}