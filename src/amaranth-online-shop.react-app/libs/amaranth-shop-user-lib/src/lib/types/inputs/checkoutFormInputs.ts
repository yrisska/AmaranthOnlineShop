import { object, string } from "yup";

export type MakeOrderFormInputs = {
  fullName: string,
  email: string,
  phone: string,
  adress: string,
  comments: string,
};

export const makeOrderSchema = object({
  fullName: string().required().min(5).max(200),
  email: string().email().required(),
  phone: string().required(),
  adress: string().required().min(10).max(200),
  comments: string().required().min(0).max(1000),
});