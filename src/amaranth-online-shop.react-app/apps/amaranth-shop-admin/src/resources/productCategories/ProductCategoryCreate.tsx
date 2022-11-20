import { Create, SimpleForm, TextInput, ImageInput, ImageField } from "react-admin";

const ProductCategoryCreate = () => {
  return (
    <Create>
      <SimpleForm>
        <TextInput source="name"/>
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

export default ProductCategoryCreate;