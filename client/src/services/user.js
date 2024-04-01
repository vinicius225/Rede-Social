export default({instante}) =>{
    const api = {
        register(user){
            return instante({
                method:"post",
                url:"user/register",
                data : user
            })
        }
    }
}