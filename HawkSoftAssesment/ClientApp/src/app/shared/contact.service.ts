import { Injectable } from '@angular/core';
import { Contact } from './contact.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }
  readonly _baseUrl = "https://localhost:44390/api/Contact";
  formData: Contact = new Contact();
  contacts: Contact[];

  getContacts(userId: number) {
    this.http.get(this._baseUrl + '/' + userId)
      .toPromise()
      .then(res => this.contacts = res as Contact[]);
  }
  insertContact(userId: number) {
    this.formData.userId = userId;
    return this.http.post(this._baseUrl, this.formData);
  }
  updateContact() {
    return this.http.put(this._baseUrl, this.formData);
  }
  deleteContact(id: number) {
    return this.http.delete(this._baseUrl + '/' + id );
  }
}
