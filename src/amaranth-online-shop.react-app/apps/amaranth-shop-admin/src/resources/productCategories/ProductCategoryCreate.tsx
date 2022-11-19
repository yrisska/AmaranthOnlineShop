import { Create, SimpleForm, ReferenceInput, TextInput, NumberInput, ImageInput } from "react-admin";

const ProductCategoryCreate = () => {
  return (
    <Create>
      <SimpleForm>
        <TextInput source="name"/>
        <TextInput source="description"/>
        <NumberInput source="price"/>
        <ReferenceInput
          source="productCategoryId"
          reference="product-categories"
        />
        <ImageInput source="imageFile"/>
      </SimpleForm>
    </Create>
  );
};

export default ProductCategoryCreate;