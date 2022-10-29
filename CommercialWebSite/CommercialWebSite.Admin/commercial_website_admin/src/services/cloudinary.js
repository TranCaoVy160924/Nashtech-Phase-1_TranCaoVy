import axios from "axios";

const uploadImage = async (imageFile) => {
   console.log("ProductDetail_ uploading image: ", imageFile);
   var formData = new FormData();
   formData.append('file', imageFile);
   formData.append('upload_preset', "mchs1zmt")

   let response = await axios.post("https://api.cloudinary.com/v1_1/dddvmxs3h/image/upload", formData)
   return response.data.url;
}

const exportObject = {
   uploadImage
};

export default exportObject;