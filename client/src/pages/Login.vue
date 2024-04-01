<script setup>
import { reactive } from 'vue';
import { RouterLink } from 'vue-router';
const formState = reactive({
    username: '',
    password: '',
    remember: true,
});
</script>

<template>
    <a-row>
        <a-col :span="24" class="logo">
            <h1>Logo</h1>
        </a-col>
    </a-row>
    <div class="form">
        <a-form :model="formState" name="basic" :label-col="{ span: 8 }" :wrapper-col="{ span: 24 }"
            autocomplete="off" @finish="onFinish" @finishFailed="onFinishFailed">
            <a-row>
                <a-col :xs="20" :sm="16" :md="12" :lg="20">
                    <a-form-item label="Login" name="username"
                        :rules="[{ required: true, message: 'Please input your username!' }]">
                        <a-input v-model:value="formState.username" />
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row>
                <a-col :xs="20" :sm="16" :md="12" :lg="20">
                    <a-form-item label="Senha" name="password"
                        :rules="[{ required: true, message: 'Please input your password!' }]">
                        <a-input-password v-model:value="formState.password" />
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row style="display: flex; justify-content: center;">
                <a-col :span="16">
                    <a-form-item>
                        <a-button type="primary" class="button" html-type="submit">Logar</a-button>
                    </a-form-item>
                </a-col>
            </a-row>
            <a-row style="display: flex; justify-content: center;">
                <a-col :span="16">
                    <a-form-item>
                        <RouterLink to="/register">
                            <a-button type="default" class="button" html-type="submit">Cadastrar</a-button>
                        </RouterLink>
                    </a-form-item>
                </a-col>
            </a-row>
        </a-form>
    </div>

</template>

<style scoped>
body {
    overflow: hidden;
    background-color: #414A50;
}

.container {
    width: 50%;
    background-color: #CAEDDE;
    margin-left: 50vh;
    margin-right: 50vh;
    margin-top: 30vh;
    border-radius: 10px;
}

.button {
    width: 100%;

}

.logo {
    display: flex;
    justify-content: center;
}

@media(max-width: 500px) {
    .container {
        width: 100%;
        background-color: #CAEDDE;
        margin-left: 0;
        margin-top: 30vh;
        border-radius: 10px;

    }
    .form{
            display: flex;
    justify-content: center;
    }
}
</style>