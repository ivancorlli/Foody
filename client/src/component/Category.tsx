import { Button, HStack, Heading } from '@chakra-ui/react'
import React from 'react'

export const Category = (props: {
  categoryId: string,
  name: string,
  idx: number
  select: (categoryId: string) => void
}) => {

  function handleClick() {
    props.select(props.categoryId)
  }

  return (
    <HStack
      w='100%'
      justifyContent='space-between'
      _hover={{
        bg: 'lightgray',
      }}
      p='5px'
      
      borderRadius={8}
    >
      <Heading
      _hover={{
        cursor: 'pointer'
      }}
      onClick={() => handleClick()}
      as='h6' size='md' fontWeight='bold' >{`${props.idx}. ${props.name}`}</Heading>
    </HStack>
  )
}
