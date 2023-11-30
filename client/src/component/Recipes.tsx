import React, { useState } from 'react'
import { HStack, VStack, Button, Heading, useDisclosure, Stack, Skeleton, Divider } from '@chakra-ui/react'
import { CategoryNewEdit } from './CategoryNewEdit'
import { Category } from './Category'
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
  const [recipes, setRecipes] = useState<IRecipe[]>([{ id: "09800dfhjk-123", title: "ejemplo", category: 'ejemplo', description: 'Esta es la desctipcion' }])
  const [selected, setSelected] = useState<string>();
  function handleSelect(recipeId: string) {
    setSelected(recipeId)
    onOpen()
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
        onClose={onClose}
        recipeId={selected}
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

