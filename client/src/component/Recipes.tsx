import React, { useEffect, useState } from 'react'
import { HStack, VStack, Button, Heading, useDisclosure, Stack, Skeleton, Divider } from '@chakra-ui/react'
import { Recipe } from './Recipe'
import { RecipeNewEdit } from './RecipeNewEdit'

interface IRecipe {
  id: string,
  title: string
  category: string,
  description: string
}

export const Recipes = () => {
  const { isOpen, onOpen, onClose } = useDisclosure()
  const [recipes, setRecipes] = useState<IRecipe[]>([])
  const [selected, setSelected] = useState<string>();
  function handleSelect(recipeId: string) {
    setSelected(recipeId)
    onOpen()
  }

  useEffect(()=>{
    async function getRecipes()
    {
      try {
        const response = await fetch(`http://localhost:5000/api/recipes`, {
          method: 'GET'
        });
        const data = await response.json();
        const lrecipes:IRecipe[]=[]
        data.forEach((e:any) => {
          const ex:IRecipe={
            id:e.id,
            title:e.title.value,
            category:e.categoryId,
            description:e.description.value
          }
          lrecipes.push(ex)
        });
        setRecipes(lrecipes)
      } catch (Exeption ) {
        console.log(Exeption)
      }
    }
    getRecipes()
  },[recipes])


  async function onUpdate() {
    try {
      const response = await fetch(`http://localhost:5000/api/recipes`, {
        method: 'GET'
      });
      const data = await response.json();
      const lrecipes:IRecipe[]=[]
      data.forEach((e:any) => {
        const ex:IRecipe={
          id:e.id,
          title:e.title.value,
          category:e.categoryId,
          description:e.description.value
        }
        lrecipes.push(ex)
      });
      setRecipes(lrecipes)
      setSelected(undefined)
    } catch (Exeption ) {
      console.log(Exeption)
    }
  }
  function handleClose()
  {
    onClose()
    setSelected(undefined) 
  }

  return (
    <VStack
      w="50%"
      h="100%"
      spacing={5}
    >
      <HStack
        align="center"
        spacing={5}
        justifyContent='space-between'
        w='100%'
      >
        <Heading as='h6' size='md' >Listado de recetas</Heading>
        <Button
          py='5px'
          onClick={() => onOpen()}
          colorScheme='blue'>
          Nueva
        </Button>
      </HStack>
      <Divider />
      <RecipeNewEdit
        isOpen={isOpen}
        onClose={handleClose}
        recipeId={selected}
        onUpdate={onUpdate}
      />
      {
        recipes.length > 0 ?
          recipes.map((e, idx) => {
            return <Recipe
              key={idx}
              RecipeId={e.id}
              title={e.title}
              idx={idx + 1}
              select={handleSelect}
            />
          })
          :
          <>
            <Stack h="100%" w="100%">
              <Skeleton height='40px' />
              <Skeleton height='40px' />
              <Skeleton height='40px' />
            </Stack>
          </>
      }
    </VStack>
  )
}

