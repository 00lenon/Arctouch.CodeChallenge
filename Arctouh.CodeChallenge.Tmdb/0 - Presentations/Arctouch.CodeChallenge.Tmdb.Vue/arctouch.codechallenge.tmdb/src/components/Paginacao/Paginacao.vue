<template src="./Paginacao.html"></template>
<style lang="less" src="./Paginacao.less"></style>

<script>
 export default{
     props: {
        paginaAtual: Number,
        quantidadeDePaginas: Number
    },
    data(){
        return {
        }
    },
    methods:{
        pageClick(pagina){
            this.$emit('pageClick', pagina);
        }
    }
}
</script>