import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  readonly _baseUrl = "https://localhost:44390/api/User";
  users: User[];
  selectedUser: User = new User();
  getUsers() {
    return this.http.get(this._baseUrl)
      .toPromise()
      .then(res => this.users = res as User[])
  }
}
