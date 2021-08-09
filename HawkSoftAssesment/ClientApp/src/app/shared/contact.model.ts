export class Contact {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  address: string;
  city: string;
  state: string;
  zipcode: string;
  isActive: boolean;
  userId: number;

  constructor() {
    this.id = 0;
    this.firstName = "";
    this.lastName = "";
    this.email = "";
    this.address = "";
    this.city = "";
    this.state = "";
    this.zipcode = "";
    this.isActive = false;
  }
}

