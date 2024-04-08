export default ({ instance }) => {
    const api = {
        registerUser(user) {
            return instance({
                method: "post",
                url: "user/register", // Verifique se o caminho da URL está correto
                data: user
            });
        }
    };

    return api;
};
