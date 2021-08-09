import { Component, Input, OnInit } from '@angular/core';
import { ContactService } from '../../shared/contact.service';
import { NgForm } from '@angular/forms';
import { Contact } from '../../shared/contact.model';
@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html',
  styles: []
})
export class ContactFormComponent implements OnInit {
  @Input() selectedUser: number;
  constructor(public contactService: ContactService) {
  }

  ngOnInit() {
  }

  onSubmit(form: NgForm) {
    if (this.contactService.formData.id == 0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.contactService.insertContact(this.selectedUser).subscribe(
      res => {
        this.resetForm(form);
        this.contactService.getContacts(this.selectedUser);
      },
      err => {
        console.log(err);
      }
    );
  }

  clearForm() {
    this.contactService.formData = new Contact();
  }

  updateRecord(form: NgForm) {
    this.contactService.updateContact().subscribe(
      res => {
        this.resetForm(form);
        this.contactService.getContacts(this.selectedUser);
      },
      err => {
        console.log(err);
      }
    );
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.clearForm();
  }
}
