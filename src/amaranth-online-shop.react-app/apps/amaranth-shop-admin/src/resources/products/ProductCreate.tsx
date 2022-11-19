import { Create, SimpleForm, ReferenceInput, TextInput, NumberInput, ImageInput, ImageField, maxLength, minLength, required, number, minValue } from "react-admin";

const validateName = [required(), minLength(4), maxLength(100)];
const validateDescription = [required(), minLength(8), maxLength(100)];
const validatePrice = [required(), number(), minValue(0)];

const ProductCreate = () => {
  return (
    <Create>
      <SimpleForm>
        <TextInput
          source="name"
          validate={validateName}
        />
        <TextInput
          source="description"
          validate={validateDescription}
        />
        <NumberInput
          source="price"
          validate={validatePrice}
        />
        <ReferenceInput
          source="productCategoryId"
          reference="product-categories"
        />
        <ImageInput
          source="imageFile"
          multiple={false}
        >
          <ImageField
            source="src"
          />
        </ImageInput>
      </SimpleForm>
    </Create>
  );
};

export default ProductCreate;