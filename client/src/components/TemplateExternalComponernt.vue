<script setup>
import { reactive } from 'vue';
import { RouterView } from 'vue-router';
const formState = reactive({
    username: '',
    password: '',
    remember: true,
});
</script>

<template>
    <div class="container">
        <a-row>
            <a-col :span="24" class="logo">
            </a-col>
        </a-row>
<RouterView></RouterView>
        </div>


</template>

<style>
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