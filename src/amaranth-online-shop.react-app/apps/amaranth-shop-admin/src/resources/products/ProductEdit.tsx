import { SimpleForm, ReferenceInput, TextInput, NumberInput, ImageInput, ImageField, Edit } from "react-admin";

const ProductEdit = () => {
  return (
    <Edit>
      <SimpleForm>
        <ImageField
          source="imageUri"
        />
        <TextInput
          disabled
          source="id"
        />
        <TextInput source="name" />
        <TextInput source="description" />
        <NumberInput source="price" />
        <ReferenceInput
          source="productCategoryId"
          reference="product-categories"
        />
        <ImageInput
          source="imageFile"
          multiple={false}
          label="New image"
        >
          <ImageField
            source="src"
          />
        </ImageInput>
      </SimpleForm>
    </Edit>
  );
};

export default ProductEdit;