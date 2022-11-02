import { object, string } from "yup";

export type MakeOrderFormInputs = {
  fullName: string,
  email: string,
  phone: string,
  adress: string,
  comments: string,
};

export const makeOrderSchema = object({
  fullName: string()
    .required("Full Name is required")
    .min(
      5,
      "Name must be at least 5 chars"
    )
    .max(200),
  email: string()
    .email("Email must be a valid email")
    .required("Email is required"),
  phone: string()
    .required("Phone is required"),
  adress: string()
    .required("Adress is required")
    .min(10)
    .max(200),
  comments: string()
    .min(0)
    .max(1000),
});