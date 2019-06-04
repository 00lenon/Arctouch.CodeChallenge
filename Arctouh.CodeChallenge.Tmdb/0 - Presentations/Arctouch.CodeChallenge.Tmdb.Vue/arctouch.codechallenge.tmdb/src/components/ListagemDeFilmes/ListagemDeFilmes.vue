<template src="./ListagemDeFilmes.html"></template>
<style lang="less" src="./ListagemDeFilmes.less" scoped></style>

<script>
import Filme from "../Filmes/Filme.vue"
 export default{
     data(){
        return {
            filmes: {},
            searchQuery:"",
            paginaAtual:1
        }
    },
    methods:{
        getFilmes(){
            console.log(this.paginaAtual);
            this.axios
                .get('https://gjrm2i1sw3.execute-api.us-east-1.amazonaws.com/Prod/Arctouh_CodeChallenge_Tmdb_UpcomingMovies?pagina='+this.paginaAtual)
                .then(response => {
                    this.filmes = JSON.parse(response.data.body);
                })
                .catch(error => console.log(error));
        },
        pageChange(pagina){
            this.paginaAtual = pagina;
            this.search();
        },
        search(){
            this.filmes = null;
            if(this.searchQuery){
                this.searchMovies(this.searchQuery)
            }else{
                this.getFilmes();
            }
        },
        searchMovies(query){
            this.axios
                .get("https://gjrm2i1sw3.execute-api.us-east-1.amazonaws.com/Prod/Arctouh_CodeChallenge_Tmdb_Search?queryString="+query+"&pagina="+this.paginaAtual)
                .then(response => {
                    this.filmes = JSON.parse(response.data.body);
                })
                .catch(error => console.log(error));
        }
    },
    mounted(){
        this.filmes = this.getFilmes(1);
    }
 }
</script>