export const api = "api";
export const uploasds = "uploads";

export const requestConfig = (method, header, data, tokden = null) => {
  let config;
  config = {
    method,
    body: JSON.stringify(data),
    headers : {
        "Content-Type" : "aplication/json"
    }
  }
  if (token){
    condfig.headers.Authorization = `Bearer ${tokden}`
  }
  return config;
};
