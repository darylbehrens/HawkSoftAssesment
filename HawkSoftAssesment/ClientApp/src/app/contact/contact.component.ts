import { Component, OnInit } from '@angular/core';
import { ContactService } from '../shared/contact.service';
import { NgForm } from '@angular/forms';
import { Contact } from '../shared/contact.model';
import { UserService } from '../shared/user.service';
import { User } from '../shared/user.model';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  selectedUser: User;

  constructor(public contactService: ContactService, public userService: UserService ) { }

  async ngOnInit() {
    await this.userService.getUsers()
      .then(res => this.selectedUser = res[0])
      .then(res => this.contactService.getContacts(this.selectedUser.id));
    
  }
  populateForm(selectedRecord: Contact) {
    this.contactService.formData = Object.assign({}, selectedRecord);
  }

  updateContacts(event) {
    this.selectedUser = this.userService.users.find(user => user.id == event.target.value);
    this.contactService.getContacts(event.target.value);
  }

  deleteContact(id: number) {
    this.contactService.deleteContact(id)
      .subscribe(
        res => {
          this.contactService.getContacts(this.selectedUser.id);
        },
        err => { console.log(err) }
      )
  }
}
