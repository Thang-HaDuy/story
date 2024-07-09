import Box from '@mui/material/Box';

const page = ({ params }: { params: { id: string } }) => {
    return <Box>{params.id}</Box>;
};

export default page;
