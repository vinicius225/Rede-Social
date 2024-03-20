import { api, requestConfig } from "../utils/config";

const register = async (data) => {
  const config = requestConfig("POST", data);
  try {
    const res = await fetch(api + "/user/register", config)
      .then((data) => data.json())
      .catch((err) => err);
    if (res) {
      localStorage.setItem("user", JSON.stringify(res));
    }
  } catch (err) {
    console.log(err);
  }
};

export default  authService = {
    register,
}
