import { SimpleForm, TextInput, ImageInput, ImageField, Edit } from "react-admin";

const ProductCategoryEdit = () => {
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

export default ProductCategoryEdit;