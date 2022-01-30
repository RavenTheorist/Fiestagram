import { Selfie } from "./selfie";

/**
 * Represents a user able to connect and upload selfies
 **/
export class User {
  name: string;
  selfies: Selfie[] = [];
}
