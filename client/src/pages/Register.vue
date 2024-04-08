<script setup>
import { reactive, ref } from 'vue';
import { RouterLink } from 'vue-router';
import services from '../services/index.js'
const formState = reactive({
    name: '',
    email: '',
    country: '',
    comfirmPassword: '',
    password: '',
    remember: true,
});
const onCadastro = () => {
    try{
    debugger
    services.registerUser(formState).then((res) => {
					alert(es.data.result);
				})
				.catch((error) => {
                    alert(error)
				})
				.then(() => {
					this.mainLoading = false;
				});
    }catch(ex){
        console.log(ex)
    }
}
const validatePassword = () => {
    if (formState.comfirmPassword == "") {
        return Promise.reject("Campo obrigatorio");
    }
    if (formState.comfirmPassword != formState.password) {
        return Promise.reject("Valor digitado esta diferente da senha");
    }
    return Promise.resolve();

}
const countries = ref([
    { value: 'CN', label: 'China' },
    { value: 'IN', label: 'India' },
    { value: 'US', label: 'United States' },
    { value: 'ID', label: 'Indonesia' },
    { value: 'PK', label: 'Pakistan' },
    { value: 'BR', label: 'Brazil' },
    { value: 'NG', label: 'Nigeria' },
    { value: 'BD', label: 'Bangladesh' },
    { value: 'RU', label: 'Russia' },
    { value: 'MX', label: 'Mexico' },
    { value: 'JP', label: 'Japan' },
    { value: 'ET', label: 'Ethiopia' },
    { value: 'PH', label: 'Philippines' },
    { value: 'EG', label: 'Egypt' },
    { value: 'VN', label: 'Vietnam' },
    { value: 'CD', label: 'DR Congo' },
    { value: 'DE', label: 'Germany' },
    { value: 'TR', label: 'Turkey' },
    { value: 'IR', label: 'Iran' },
    { value: 'TH', label: 'Thailand' },
    { value: 'GB', label: 'United Kingdom' },
    { value: 'FR', label: 'France' },
    { value: 'IT', label: 'Italy' },
    { value: 'TZ', label: 'Tanzania' },
    { value: 'ZA', label: 'South Africa' },
    { value: 'MM', label: 'Myanmar' },
    { value: 'KE', label: 'Kenya' },
    { value: 'KR', label: 'South Korea' },
    { value: 'CO', label: 'Colombia' },
    { value: 'ES', label: 'Spain' },
    { value: 'UG', label: 'Uganda' },
    { value: 'AR', label: 'Argentina' },
    { value: 'DZ', label: 'Algeria' },
    { value: 'SD', label: 'Sudan' },
    { value: 'UA', label: 'Ukraine' },
    { value: 'IQ', label: 'Iraq' },
    { value: 'AF', label: 'Afghanistan' },
    { value: 'PL', label: 'Poland' },
    { value: 'CA', label: 'Canada' },
    { value: 'MA', label: 'Morocco' },
    { value: 'SA', label: 'Saudi Arabia' },
    { value: 'UZ', label: 'Uzbekistan' },
    { value: 'PE', label: 'Peru' },
    { value: 'VE', label: 'Venezuela' },
    { value: 'MY', label: 'Malaysia' },
    { value: 'GH', label: 'Ghana' },
    { value: 'NP', label: 'Nepal' },
]);
</script>

<template>
    <a-row>
        <a-col :span="24" class="logo">
            <h1>Logo</h1>
        </a-col>
    </a-row>
    <div class="form">
        <a-form :model="formState" name="basic" :label-col="{ span: 8 }" :wrapper-col="{ span: 24 }"
            @finish="onCadastro" autocomplete="off">
            <a-row>
                <a-col :xs="20" :sm="16" :md="12" :lg="20">
                    <a-form-item label="Nome" name="name" :rules="[{ required: true, message: 'Insira seu nome' }]">
                        <a-input v-model:value="formState.name" />
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row>
                <a-col :xs="20" :sm="16" :md="12" :lg="20">
                    <a-form-item label="País" name="country" :rules="[{ required: true, message: 'Insira seu país' }]">
                        <a-select v-model:value="formState.country" show-search placeholder="Select a person"
                            :options="countries" ></a-select>
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row>
                <a-col :xs="20" :sm="16" :md="12" :lg="20">
                    <a-form-item label="E-mail" name="email"
                        :rules="[{ required: true, message: 'Informe o seu E-mail' }]">
                        <a-input v-model:value="formState.email" />
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row>
                <a-col :xs="20" :sm="16" :md="12" :lg="20">
                    <a-form-item label="Senha" name="password"
                        :rules="[{ required: true, message: 'Digite sua senha' }]">
                        <a-input-password v-model:value="formState.password" />
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row>
                <a-col :xs="20" :sm="16" :md="12" :lg="20">
                    <a-form-item label="Confirmar Senha" name="confirmPassword"
                    :rules="[{ validator: validatePassword }]">
                    <a-input-password v-model:value="formState.comfirmPassword" />
                </a-form-item>
                </a-col>
            </a-row>

            <a-row style="display: flex; justify-content: center;">
                <a-col :span="16">
                    <a-form-item>
                        <a-button type="primary" class="button" html-type="submit">Cadastrar</a-button>
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row style="display: flex; justify-content: center;">
                <a-col :span="16">
                    <a-form-item>
                        <RouterLink to="/register">
                            <a-button type="default" class="button" html-type="submit">Voltar</a-button>
                        </RouterLink>
                    </a-form-item>
                </a-col>
            </a-row>
        </a-form>
    </div>

</template>

<style scoped></style>