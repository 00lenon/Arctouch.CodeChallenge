<template src="./Filme.html"></template>
<style lang="less" src="./Filme.less"></style>

<script>
 export default{
     props: {
            filme: {}
    },
    data(){
        return{
            urlDeImagens: "https://image.tmdb.org/t/p/w500/",
            urlDeDetalhes: "/filme/"
        }
    },
    
}
</script>