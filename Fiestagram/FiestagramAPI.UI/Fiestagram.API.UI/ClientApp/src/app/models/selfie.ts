import { User } from "./user";

/**
 * A selfie is an image that has been uploaded by a user
 **/
export class Selfie {
  imageURL: string;
  user: User;
  title: string;

  constructor()
  {
    this.user = new User();
  }
}
