<template src="./DetalhesDoFilme.html"></template>
<style lang="less" src="./DetalhesDoFilme.less" scoped></style>

<script>
 export default{
    data(){
        return{
            urlDeImagens: "https://image.tmdb.org/t/p/w500/",
            filme: {},
        }
    },
    methods:{
        getFilme(id){
            this.axios
                .get('https://gjrm2i1sw3.execute-api.us-east-1.amazonaws.com/Prod/Arctouh_CodeChallenge_Tmdb_MovieDetails?movieId=' + id)
                .then(response => {
                    this.filme = JSON.parse(response.data.body);
                })
                .catch(error => console.log(error));
        }
    },
     mounted(){
        this.filme = this.getFilme(this.$route.params.id);
    }
}
</script>