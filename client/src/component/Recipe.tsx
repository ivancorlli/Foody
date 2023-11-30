import { Button, HStack, Heading } from '@chakra-ui/react'
import React from 'react'

export const Recipe = (props: {
  RecipeId: string,
  title: string,
  idx: number
  select: (recipeId: string) => void
}) => {

  function handleClick() {
    props.select(props.RecipeId)
  }
  async function handleDelete() {
    try {
      const response = await fetch(`http://localhost:5000/api/recipes${props.RecipeId}`, {
        method: 'DELETE',
        mode: 'no-cors',
        credentials: 'omit',
        headers: {
          'Content-Type': 'application/json'
        }
      });
      response.json(); // parses JSON response into native JavaScript objects
    } catch (Exeption) {

    }
  }

  return (
    <HStack
      w='100%'
      justifyContent='space-between'
      _hover={{
        bg: 'lightgray',
        cursor: 'pointer'
      }}
      p='5px'
      borderRadius={8}
      onClick={() => handleClick()}
    >
      <Heading as='h6' size='md' fontWeight='bold' >{`${props.idx}. ${props.title}`}</Heading>
      <Button
        py='5px'
        onClick={() => handleDelete()}
        colorScheme='red'>
        Eliminar
      </Button>

    </HStack>
  )
}

